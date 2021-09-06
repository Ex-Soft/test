/* https://docs.confluent.io/clients-kafka-java/current/overview.html */

import com.mycorp.mynamespace.RootType;
import com.nordstrom.care.communications.EmailCommunicationRequested;
import io.confluent.kafka.serializers.KafkaAvroDeserializer;
import io.confluent.kafka.serializers.KafkaAvroDeserializerConfig;
import io.confluent.kafka.serializers.KafkaAvroSerializer;
import org.apache.avro.specific.SpecificRecordBase;
import org.apache.kafka.clients.consumer.ConsumerConfig;
import org.apache.kafka.clients.consumer.ConsumerRecord;
import org.apache.kafka.clients.consumer.ConsumerRecords;
import org.apache.kafka.clients.consumer.KafkaConsumer;
import org.apache.kafka.clients.producer.Callback;
import org.apache.kafka.clients.producer.KafkaProducer;
import org.apache.kafka.clients.producer.ProducerRecord;
import org.apache.kafka.clients.producer.RecordMetadata;
import org.apache.kafka.common.serialization.StringDeserializer;
import org.apache.kafka.common.serialization.StringSerializer;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.time.Duration;
import java.util.Arrays;
import java.util.Properties;

public class TestSchema {
    public static void main(String[] args) {
        //produce();
        consume();
    }

    /* public static void produce() {
        Logger logger = LoggerFactory.getLogger(TestSchema.class);
        logger.info("This is how you configure Java Logging with SLF4J");

        Properties properties = new Properties();
        properties.setProperty("bootstrap.servers", "127.0.0.1:9092");
        properties.setProperty("acks", "1");
        properties.setProperty("retries", "10");

        properties.setProperty("key.serializer", StringSerializer.class.getName());
        properties.setProperty("value.serializer", KafkaAvroSerializer.class.getName());
        properties.setProperty("schema.registry.url", "http://127.0.0.1:8081");

        KafkaProducer<String, RootType> kafkaProducer = new KafkaProducer<>(properties);
        String topic = "test-topic";

        RootType rootType = RootType.newBuilder()
                .setInnerComplexValue(
                        com.mycorp.mynamespace.InnerType1.newBuilder()
                                .setId(1)
                                .setValue("1st")
                                .build()
                )
                .build();

        ProducerRecord<String, RootType> producerRecord = new ProducerRecord<String, RootType>(topic, "1", rootType);

        try {
            kafkaProducer.send(producerRecord, new Callback() {
                @Override
                public void onCompletion(RecordMetadata recordMetadata, Exception exception) {
                    if (exception == null) {
                        System.out.println("Success!");
                        System.out.println(recordMetadata.toString());
                    } else {
                        exception.printStackTrace();
                    }
                }
            });
        }
        catch (Exception e) {
            e.printStackTrace();
        }
        finally {
            kafkaProducer.flush();
            kafkaProducer.close();
        }
    } */

    public static void consume() {
        Logger logger = LoggerFactory.getLogger(TestSchema.class);
        logger.info("This is how you configure Java Logging with SLF4J");

        Properties properties = new Properties();
        properties.setProperty(ConsumerConfig.BOOTSTRAP_SERVERS_CONFIG, "brook.nonprod.us-west-2.aws.proton.nordstrom.com:9093" /*"127.0.0.1:9092"*/);
        properties.setProperty(ConsumerConfig.GROUP_ID_CONFIG, java.util.UUID.randomUUID().toString());

        String username = "resplendent-ermine.W76KGBB2UKOFM3N0W";
        String password = "HyQaeevpJ843lTGem08LDNa51vluVHsTf6SQOvmxiOgypkNMVUH4CZFQmehXiO8oSYAy1X-eVCCmkhOdVP_9j6b-tpGE5maALRxKXQtrSMHWq97t6yPsZfzERP8AmERZ";
        String jaasTemplate = "org.apache.kafka.common.security.scram.ScramLoginModule required username=\"%s\" password=\"%s\";";
        String jaasCfg = String.format(jaasTemplate, username, password);

        properties.setProperty(ConsumerConfig.KEY_DESERIALIZER_CLASS_CONFIG, StringDeserializer.class.getName());
        properties.setProperty(ConsumerConfig.VALUE_DESERIALIZER_CLASS_CONFIG, KafkaAvroDeserializer.class.getName());
        properties.setProperty("schema.registry.url", "https://schema-registry.nonprod.us-west-2.aws.proton.nordstrom.com" /*"http://localhost:8081"*/);
        properties.setProperty("security.protocol", "SASL_SSL");
        properties.setProperty("sasl.mechanism", "SCRAM-SHA-512");
        properties.setProperty("sasl.username", username);
        properties.setProperty("sasl.password", password);
        properties.setProperty("sasl.jaas.config", jaasCfg);
        properties.setProperty("ssl.ca.location", "/certs/ProtonCert.pem");
        properties.setProperty("basic.auth.credentials.source", "USER_INFO");
        properties.setProperty("basic.auth.user.info", String.format("%s:%s", username, password));
        properties.put(KafkaAvroDeserializerConfig.SPECIFIC_AVRO_READER_CONFIG, true);

        properties.put(ConsumerConfig.AUTO_OFFSET_RESET_CONFIG, "earliest");

        KafkaConsumer<String, SpecificRecordBase /*EmailCommunicationRequested*/ /*RootType*/> kafkaConsumer = new KafkaConsumer<>(properties);
        String topic = "order-events-avro"; //"test-topic";

        kafkaConsumer.subscribe(Arrays.asList(topic));

        try {
            while (true) {
                ConsumerRecords<String, SpecificRecordBase /*EmailCommunicationRequested*/ /*RootType*/> records = kafkaConsumer.poll(Duration.ofMillis(100));

                if (records.isEmpty()) {
                    continue;
                }

                for (ConsumerRecord<String, SpecificRecordBase /*EmailCommunicationRequested*/ /*RootType*/> record : records) {
                    System.out.printf("offset = %d, key = %s, value = %s \n", record.offset(), record.key(), record.value());
                }
            }
        }
        catch (Exception e) {
            e.printStackTrace();
        }
        finally {
            kafkaConsumer.close();
        }
    }
}
